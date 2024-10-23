import { Routes } from '@angular/router';
import { LandingPageComponent } from './Pages/landing-page/landing-page.component';
import { CreateClienteComponent } from './Forms/create-cliente/create-cliente.component';
import { CreatePrestamoComponent } from './Forms/create-prestamo/create-prestamo.component';
import { SignupComponent } from './AuthPages/signup/signup.component';
import { AboutComponent } from './Pages/about/about.component';
import { FAQComponent } from './Pages/faq/faq.component';
import { LoginComponent } from './AuthPages/login/login.component';

export const routes: Routes = [
{
    path: 'landing',
    component: LandingPageComponent,
},{
path:"create/client",
component:CreateClienteComponent
},{
    path:"create/prestamo",
    component:CreatePrestamoComponent
},{
    path:"login",
    component:LoginComponent
},{
    path:"signup",
    component:SignupComponent
},{
    path: 'about',
    component:AboutComponent,
},{
path:"faq",
component:FAQComponent

},
{
path:"",
redirectTo: '/landing',
pathMatch: 'full'
}

];
