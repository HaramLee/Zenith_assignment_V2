export class Login {
    token_type : string;
    access_token : string;

    constructor(obj?: any){
        this.token_type = obj && obj.token_type || null;
        this.access_token = obj && obj.access_token || null;
    }
}
