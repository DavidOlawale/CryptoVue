import { Routes } from '@angular/router';
import { InfoPageComponent } from './info-page/info-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { UpdatePageComponent } from './update-page/update-page.component';

export const routes: Routes = [
    {
        path: '',
        component: InfoPageComponent,
        title: 'BLP token data'
    },
    {
        path: 'login',
        component: LoginPageComponent,
        title: 'Login'
    },
    {
        path: 'update',
        component: UpdatePageComponent,
        title: 'Update BLP token data'
    }
];
