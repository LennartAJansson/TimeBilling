$hostname=""
$url = "http://buildversionsapi.local:8080"
$curl = "curl.exe"
$configuration = "production"
$namespace = "timebilling"
$deploy = "deploy"
$kubeseal = "kubeseal"

$alive = &${curl} -s "${url}/Ping" -H "accept: text/plain"
if($alive -ne "pong")
{
	"You need to do an initial deploy of BuildVersionsApi"
	"Please run InitBuildVersion.ps1"
	return
}

foreach($name in @(
	"TimeBilling.Web", 
	"TimeBilling.Api"
))
{
	$lowerName = $name.ToLower() 
	$lowerName = $lowerName -replace "\."

	$buildVersion = $null
	$buildVersion = &${curl} -s "${url}/buildversions/GetVersionByName/${name}" | ConvertFrom-Json
	$semanticVersion = $buildVersion.semanticVersion

	if([string]::IsNullOrEmpty($semanticVersion)) 
	{
		"Could not connect to buildversionsapi"
		"Please check that BuildVersionsApi is working correctly in your Kubernetes"
		return
	}

	"Current deploy: ${env:REGISTRYHOST}/${lowerName}:${semanticVersion}"

	cd ./${deploy}/${name}

	kustomize edit set image "${env:REGISTRYHOST}/${lowerName}:${semanticVersion}"

	if(Test-Path -Path ./secrets/*)
	{
		"Creating secrets"
		kubectl create secret generic ${lowerName}-secret --output json --dry-run=client --from-file=./secrets |
			&${kubeseal} -n "${namespace}" --controller-namespace kube-system --format yaml > "secret.yaml"
	}

	cd ../..

	kubectl apply -k ./${deploy}/${name}
	
	#Restore secret.yaml and kustomization.yaml since this script alters them temporary
	#if([string]::IsNullOrEmpty($env:AGENT_NAME) -and [string]::IsNullOrEmpty($hostname))
	if([string]::IsNullOrEmpty($env:AGENT_NAME))
	{
		if(Test-Path -Path ${deploy}/${name}/secret.yaml)
		{
			git checkout ${deploy}/${name}/secret.yaml
		}
		git checkout ${deploy}/${name}/kustomization.yaml
	}
}

#EXAMPLE OF PROMETHEUS QUERIES:
#container_last_seen{pod="nats-0"}
#http_request_duration_seconds_sum{method="GET",controller="Query"}
#workloadsapi_controllers_executiontime{path="/api/Query/GetAssignments"}
#workloadsapi_controllers_executiontime{path="/api/Query/GetPeople"}
#workloadsapi_controllers_executiontime{path="/api/Query/GetWorkloads"}
#http_request_duration_seconds_sum{method=~"GET|POST|PUT|DELETE",controller=~"Query|Command"}
#workloadsapi_controllers_executiontime{path=~"/api/Query/GetAssignments|/api/Query/GetPeople|/api/Query/GetWorkloads|/api/Command/CreatePerson|/api/Command/CreateAssignment|/api/Command/CreateWorkload|/api/Command/UpdateWorkload"}
#container_memory_usage_bytes{container=~"cronjob|buildversion|workloadsapi|workloadsprojector|countriesapi"}