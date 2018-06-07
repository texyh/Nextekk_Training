import { Component, OnInit, ViewChild } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Product } from "../common/models/product.model";
import { ProductService } from "../common/service/product.service";

@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
    products: Product[];
    newProduct: Product;

    private _products: Product[];

    @ViewChild('form')
    private form: NgForm;

    get canSave(): boolean {
        return this.form.valid;
    }

    constructor(private productService: ProductService) {
        this.products = [];
        this._products = [];
        this.newProduct = new Product();
    }

    ngOnInit() {
        this.productService.getAllProducts().subscribe(data => {
            this.products = this._products = data;
        });
    }

    searchProduct($event) {
        const value = $event.currentTarget.value.toLowerCase();

        this.products = this._products.filter((product: Product) => product.name.toLowerCase().includes(value));
    }

    addProduct() {
        if (this.form.dirty && this.form.valid) {
            this.productService.addProduct(this.newProduct).subscribe(data => {
                this.newProduct.id = data;
                this._products.push(this.newProduct);
                this.products = this._products;
                alert(`${this.newProduct.name} was added successfully`);
            });
        }
    }

    updateProduct(product: Product) {
        this.productService.updateProduct(product).subscribe();
    }

    deleteProduct(id: number) {
        this.productService.deleteProduct(id).subscribe(data => {
            alert('Product was removed successfully');
        });
    }
}
