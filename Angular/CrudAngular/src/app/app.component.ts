import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TablaApiComponent } from "./components/tabla-api/tabla-api.component";
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TablaApiComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'CrudAngular';
}
