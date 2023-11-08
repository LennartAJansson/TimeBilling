import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor() {}
//  constructor(private authService: AuthService,
//    private router: Router) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
//    var token = this.authService.getToken();

//    if (token) {
//      request = request.clone({
//        setHeaders: {
//          Authorization: `Bearer ${token}`
//        }
//      });
//    }

//    return next.handle(request).pipe(
//      catchError((error) => {
//        // Perform logout on 401 - Unauthorized HTTP response errors
//        if (error instanceof HttpErrorResponse && error.status === 401) {
//          this.authService.logout();
//          this.router.navigate(['login']);
//        }
//        return throwError(error);
//      })
//    );

    return next.handle(request);
  }
}
