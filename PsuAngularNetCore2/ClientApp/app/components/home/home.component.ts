import { Component, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {

    public TableValues: ShortResult;
    public Columns: any;

    constructor(private http: Http) {

    }

    

    onSubmit(f: NgForm) {
        console.log(f.value);  // { first: '', last: '' }
        let postValue = { "Cn": f.value.Cn, "Sn": f.value.Sn, "Uid": f.value.Uid, "Mail": f.value.Mail, "full": f.value.full };
        this.http.get("/api/PennState/").subscribe(result => {
                this.Columns = result.json();
            },
            error => console.error(error));

        this.http.post("/api/PennState/", postValue).subscribe(result => {
            this.TableValues = result.json() as ShortResult;
        }, error => console.error(error));

       
    
    }
}

interface ShortResult {
    name: string;
    email: string;
    mailId: string;
    title: string;
    adminArea: string;
    campus: string;
    curriculum: string;
    url: string;
    telephoneNumber: string;
    countries: string;
    languages: string;
}
