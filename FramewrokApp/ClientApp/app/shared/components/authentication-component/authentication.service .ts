import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { LoginModel } from "../../models/login.model";
import { HttpHeaders, HttpResponse } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { UserInfo } from "../../models/user-info.model";

@Injectable()
export class AuthenticationService {
    private tokenResult: any;
    constructor(private http: HttpClient) { }

    isAuthenticated(login: LoginModel): Observable<boolean> {
        let httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        };

        let body = JSON.stringify(login);
        return this.http.post('api/Token/CreateToken', body, httpOptions).pipe(map(result => {
            this.tokenResult = result;
            if (this.tokenResult && this.tokenResult.jwtToken.token) {
                localStorage.setItem('tokenInfo', JSON.stringify(this.tokenResult.jwtToken));
                this.setUserInfo();
                return true;
            } else {
                return false;
            }
        }));

    }

    setUserInfo() {
        return this.http.get('api/User/GetUserInfo').subscribe((result) => {
             if (result) {
                 localStorage.setItem('userInfo', JSON.stringify(result));
            }
        });
        //return this.http.get('api/User/GetUserInfo').pipe(map(result => {
        //    if (result) {
        //        console.log(result);
        //        localStorage.setItem('userInfo', JSON.stringify(result));
        //    }
        //}));
    }

    public getUserInfo() {
        let userInfo = JSON.parse(localStorage.getItem('userInfo'));
        console.log(JSON.parse(localStorage.getItem('userInfo')));
        return <UserInfo>userInfo;
    }

    public getToken() {
        let token = JSON.parse(localStorage.getItem('tokenInfo'));
        if (token) {
            return token.token;
        }
        return null;
        
    }
}