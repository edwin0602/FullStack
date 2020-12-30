import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class BusinessService {

    configUrl = 'https://localhost:44372';

    constructor(private http: HttpClient) { }

    saveVehicle(item: any) {
        return this.http.post(`${this.configUrl}/api/Vehicle`, item).toPromise();
    }

    getVehicles() {
        return this.http.get(`${this.configUrl}/api/Vehicle`).toPromise();
    }

    getVehicleTypes() {
        return this.http.get(`${this.configUrl}/api/Vehicle/types`).toPromise();
    }

    getVehicleBrands() {
        return this.http.get(`${this.configUrl}/api/Vehicle/brands`).toPromise();
    }

}