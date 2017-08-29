import { Component, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {

    public Shorty: ShortResult;

    constructor(private http: Http) {}

    onSubmit(f: NgForm) {
        console.log(f.value);  // { first: '', last: '' }
        let thingy = { "Cn": f.value.Cn, "Sn": f.value.Sn, "Uid": f.value.Uid, "Mail": f.value.Mail };

        this.http.post("http://localhost:57156/api/PennState/", thingy).subscribe(result => {
            this.Shorty = result.json() as ShortResult;
        }, error => console.error(error));
    
    }
}

interface ShortResult {
    name: string;
    email: string;
    mailId: string;
    title: string;
}
