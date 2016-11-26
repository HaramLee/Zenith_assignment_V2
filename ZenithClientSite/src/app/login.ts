export class Login {
    token_type : String;
    access_token : String;

    constructor(obj?: any){
        this.token_type = obj && obj.token_type || null;
        this.access_token = obj && obj.access_token || null;
    }
}
