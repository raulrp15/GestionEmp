import { Routes } from '@angular/router';
import { TablaPersonasComponent } from './components/tabla-personas/tabla-personas.component';
import { FormulariopersonaComponent } from './components/formulariopersona/formulariopersona.component';

export const routes: Routes = [
    {path:'tabla', component: TablaPersonasComponent},
    {path:'formulario', component: FormulariopersonaComponent}
];
