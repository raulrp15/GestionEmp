import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { TablaPersonasComponent } from './components/tabla-personas/tabla-personas.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TablaPersonasComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'بابلو كاربونيرو زعيم داعش';
}
