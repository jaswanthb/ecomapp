import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {GetCustomersComponent} from './get-customers/get-customers.component'

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, GetCustomersComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'eCommUI';
}
