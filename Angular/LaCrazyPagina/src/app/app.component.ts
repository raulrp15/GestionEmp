import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { TablaApiPersonasComponent } from "./components/tabla-api-personas/tabla-api-personas.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TablaApiPersonasComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'بابلو كاربونيرو زعيم داعش';
}
