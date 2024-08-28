import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Product } from '../Models/product';
import { FavsDirective } from '../custom/favs.directive';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-directive-sample',
  standalone: true,
  imports: [FormsModule, CommonModule, FavsDirective],
  templateUrl: './directive-sample.component.html',
  styleUrl: './directive-sample.component.css'
})
export class DirectiveSampleComponent {
  num: number;
  colorList: string[];
  products: Product[];
  selectedColor: string = "red";
  id: string | undefined;
  city: string|undefined;
  country: string|undefined;

  constructor(private activatedRoute: ActivatedRoute) {
    this.num = 0;
    this.colorList = ["red", "green", "blue"];
    this.products = [];

    let p1 = new Product(101, "Laptop", "P001", 23000);
    let p2 = new Product(102, "Desktop", "P002", 16000);
    let p3 = new Product(103, "Tablet", "P003", 10999);
    this.products.push(p1);
    this.products.push(p2);
    this.products.push(p3);

    this.activatedRoute.params.subscribe(data => {
      this.id = data["id"] // Read parameters from url
    })

    this.activatedRoute.queryParams.subscribe(data => {
      this.city = data["city"];
      this.country = data["country"];
    })
  }

  addNewProduct() {
    this.products.push(new Product(104, "Phone", "P004", 45000));
  }
  showAlert() {
    alert("test");
  }
}
