import { Component } from '@angular/core';
import { NbAuthResult, NbRegisterComponent } from '@nebular/auth';
import { RegisterDto, User } from '../../shared/api/api';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent extends NbRegisterComponent {
  override user: RegisterDto = {} as RegisterDto;
  override redirectDelay = 1000;

  override register(): void {
    this.errors = this.messages = [];
    this.submitted = true;

    this.service
      .register(this.strategy, this.user)
      .subscribe((result: NbAuthResult) => {
        this.submitted = false;
        const redirect = result.getRedirect();

        setTimeout(() => {
          return this.router.navigateByUrl('/auth/register-success');
        }, this.redirectDelay);

        // debugger;
        // if (result.isSuccess()) {
        //   this.messages = result.getMessages();
        // } else {
        //   this.errors = result.getErrors();
        // }
        //
        // if (redirect) {
        //   setTimeout(() => {
        //     return this.router.navigateByUrl(redirect);
        //   }, this.redirectDelay);
        // }
        //this.router.navigateByUrl('/auth/register-success');
        this.cd.detectChanges();
      });
  }
}
