import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { LoginModel } from "../../models/login.model";
import { HttpHeaders, HttpResponse } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable()
export class AuthenticationService {
    private tokenResult: any;
    constructor(private http: HttpClient) { }


    login(login: LoginModel): Observable<boolean> {

        let httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        };

        let body = JSON.stringify(login);

        return this.http.post('api/Token/CreateToken', body, httpOptions).pipe(map(result => {
            this.tokenResult = result;
            console.log(this.tokenResult);
            if (this.tokenResult && this.tokenResult.jwtToken.token) {
                localStorage.setItem('tokenInfo', JSON.stringify(this.tokenResult.jwtToken));
                return true;
            }
            return false;
        }));

    }

}