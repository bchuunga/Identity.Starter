import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbThemeModule, NbLayoutModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { LayoutModule } from './layout/layout.module';
import { SharedModule } from './shared/shared.module';
import { NbAuthModule, NbPasswordAuthStrategy } from '@nebular/auth';
import { AuthGuard } from './auth/auth.guard';

export interface NbAuthSocialLink {
  link?: string;
  url?: string;
  target?: string;
  title?: string;
  icon?: string;
}

const socialLinks: NbAuthSocialLink[] = [];

const formSetting: any = {
  redirectDelay: 1000,
  strategy: 'email',
  showMessages: {
    success: true,
    error: true,
  },
  terms: false,
  admin: false,
};

const loginFormSetting: any = {
  redirectDelay: 1000,
  strategy: 'email',
  showMessages: {
    success: true,
    error: true,
  },
  terms: true,
};

const registerFormSetting: any = {
  redirectDelay: 1000,
  strategy: 'email',
  showMessages: {
    success: true,
    error: true,
  },
  terms: true,
  admin: true,
};

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    BrowserAnimationsModule,
    NbThemeModule.forRoot({ name: 'corporate' }),
    NbLayoutModule,
    NbEvaIconsModule,
    LayoutModule,
    NbAuthModule.forRoot({
      strategies: [
        NbPasswordAuthStrategy.setup({
          name: 'email',
          baseEndpoint: 'https://localhost:7015',
          login: {
            endpoint: '/api/Account/login',
            method: 'post',
            redirect: {
              success: '/pages/welcome',
              failure: null,
            },
          },
          register: {
            endpoint: '/api/Account/register',
            method: 'post',
            redirect: {
              success: '/auth/register-success',
              failure: null,
            },
          },
        }),
      ],
      forms: {
        login: loginFormSetting,
        register: registerFormSetting,
        registerSuccess: formSetting,
        requestPassword: formSetting,
        resetPassword: formSetting,
        logout: {
          redirectDelay: 500,
          strategy: 'email',
        },
        validation: {
          password: {
            required: true,
            minLength: 4,
            maxLength: 50,
          },
          email: {
            required: true,
          },
          firstName: {
            required: true,
            minLength: 3,
            maxLength: 150,
          },
          lastName: {
            required: true,
            minLength: 3,
            maxLength: 150,
          },
        },
      },
    }),
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent],
})
export class AppModule {}
