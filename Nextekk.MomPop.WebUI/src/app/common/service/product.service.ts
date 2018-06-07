import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Product } from "../models/product.model";
import { Observable } from "rxjs";

@Injectable()
export class ProductService {
    apiURL: string = 'http://localhost:50781/api/Products';

    constructor(private _http: HttpClient) {}

    getAllProducts(): Observable<Product[]> {
        return this._http.get<Product[]>(this.apiURL);
    }

    addProduct(product: Product): Observable<number> {
        return this._http.post<number>(this.apiURL, product);
    }

    updateProduct(product: Product) {
        return this._http.put(`${this.apiURL}/${product.id}`, product);
    }

    deleteProduct(id: number): Observable<any> {
        return this._http.delete(this.apiURL, { params: { id: id.toString() } });
    }
}
