import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { DatabindingComponent } from './databinding/databinding.component';
import { DirectiveSampleComponent } from './directive-sample/directive-sample.component';
import { PipeSampleComponent } from './pipe-sample/pipe-sample.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, DatabindingComponent, DirectiveSampleComponent,PipeSampleComponent, RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'sampleapp';
}
