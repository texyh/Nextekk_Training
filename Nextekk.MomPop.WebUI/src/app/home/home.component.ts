import { Component, OnInit } from "@angular/core";
import { ProductService } from "../common/service/product.service";
import { Product } from "../common/models/product.model";

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
    products: Product[];

    constructor(private _productService: ProductService) {
        this.products = [];
    }

    ngOnInit(): void {
        this._productService.getAllProducts().subscribe(data => {
            this.products = data;
        });
    }
}
