import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  name: string = 'Dele';
  title = 'NexTekk';

  value = 780;

  greet() {
    alert('Hello!');
  }
}
