import { Component, input } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TablaPersonasComponent } from './components/tabla-personas/tabla-personas.component';
import { FormulariopersonaComponent } from './components/formulariopersona/formulariopersona.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TablaPersonasComponent, FormulariopersonaComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  title = 'holaMundoAngular';
}
