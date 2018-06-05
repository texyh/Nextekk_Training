import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Product } from "../models/product.model";

@Injectable()
export class ProductService {
    apiURL: string = 'http://localhost:50781/api/Products';

    constructor(private _http: HttpClient) {}

    getAllProducts() {
        return this._http.get<Product[]>(this.apiURL);
    }
}