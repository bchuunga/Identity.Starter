import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import {
  NbAlertModule,
  NbButtonModule,
  NbCardModule,
  NbCheckboxModule,
  NbIconModule,
  NbInputModule,
} from '@nebular/theme';
import { SharedModule } from '../shared/shared.module';
import { NbAuthModule } from '@nebular/auth';
import { RegisterSuccessComponent } from './register-success/register-success.component';

@NgModule({
  declarations: [LoginComponent, RegisterComponent, RegisterSuccessComponent],
  imports: [
    SharedModule,
    AuthRoutingModule,
    NbAlertModule,
    NbInputModule,
    NbButtonModule,
    NbCheckboxModule,
    NbCardModule,
    NbAuthModule,
    NbIconModule,
  ],
})
export class AuthModule {}
