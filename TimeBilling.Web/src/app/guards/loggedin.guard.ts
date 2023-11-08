import { CanActivateFn } from '@angular/router';

export const loggedinGuard: CanActivateFn = (route, state) => {
//    if (this.authService.isAuthenticated()) {
//      return true;
//    }
//    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
//    return false;
  return true;
};
