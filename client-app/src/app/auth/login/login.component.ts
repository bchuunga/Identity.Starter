import { Component } from '@angular/core';
import { NbLoginComponent } from '@nebular/auth';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent extends NbLoginComponent {
  // loginForm!: FormGroup;
  //
  // constructor(private readonly fb: FormBuilder) {
  //   // @ts-ignore
  //   super();
  // }
  //
  // ngOnInit(): void {
  //   this.loginForm = this.fb.group({});
  // }
  //
  // get f() {
  //   return this.loginForm.controls;
  // }
  //
  // onSubmit() {}
  //
  // onReset() {}
}
