import { Component, OnInit} from '@angular/core';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import Item from './models/item';

@Component({
    selector: 'my-app',
    templateUrl: '../Scripts/App/app.component.html'
})

export class AppComponent implements OnInit {
    temp: string;
    result: Item[];
    firstItem: string;

    constructor(private http: Http) {
        this.temp = "Welcome";
    }

    ngOnInit() {
        console.log("hello")
    }

    btnClickedEvent(): void {
        console.log("button has been clicked");
        this.getResponse()
                .subscribe(
                    result => {
                        console.log(result);
                        this.result = result;
                        this.firstItem = result[0].title;
                    },
                    error =>  console.log(<any>error));
    }

    getResponse(): Observable<Item[]>{
        return this.http.get("http://localhost:53499/api/values")
                    .map(this.extractData)
                    .catch(this.handleError);
    }

    private extractData(res: Response) {
        console.log(res)
        let body = res.json();
        console.log(body)
        return body || { };
    }

    private handleError(error: Response | any) {
        // In a real world app, you might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
              const body = error.json() || '';
              const err = body.error || JSON.stringify(body);
              errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}