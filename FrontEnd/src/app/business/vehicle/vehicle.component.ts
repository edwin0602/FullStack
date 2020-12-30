import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { BusinessService } from 'app/config/business.service';

@Component({
    selector: 'app-vehicle',
    templateUrl: './vehicle.component.html',
    styleUrls: []
})

export class VehicleComponent implements OnInit {

    vehicles = [];

    vehicleBrands = [];
    vehicleTypes = [];

    canSubmit = false;

    constructor(private backend: BusinessService) { }

    ngOnInit() {
        this.backend.getVehicles().then((data: []) => this.vehicles = data);

        this.backend.getVehicleBrands().then((brands: []) => {
            this.vehicleBrands = brands;
            return this.backend.getVehicleTypes();
        }).then((types: []) => {
            this.vehicleTypes = types;
            this.canSubmit = true;
        })
    }

    onSubmit(f: NgForm) {
        if (f.valid) {
            this.canSubmit = false;

            var toSubmit = f.value;

            toSubmit.year = `${toSubmit.year}`;
            toSubmit.cylinderCap = `${toSubmit.cylinderCap}`;

            this.backend.saveVehicle(toSubmit).then(x => {
                this.vehicles.push(x);
                f.resetForm();
            }).catch(err => {
                alert(err.error[0].errorMessage);
            }).finally(() => this.canSubmit = true)
        }
    }

}
