import { Routes } from '@angular/router';
import { FormularioPersonasComponent } from './components/formulario-personas/formulario-personas.component';
import { ListadoPersonasComponent } from './components/listado-personas/listado-personas.component';
import { TablaPersonasComponent } from './components/tabla-personas/tabla-personas.component';

export const routes: Routes = [
    {path: 'formulario', component: FormularioPersonasComponent},
    {path: 'listado', component: ListadoPersonasComponent},
    {path: 'tabla', component: TablaPersonasComponent}
];
