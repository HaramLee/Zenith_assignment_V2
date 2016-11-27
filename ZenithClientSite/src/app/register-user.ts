export class RegisterUser {
    firstName: string;
    lastName: string;
    email: string;
    userName: string;
    passwordHash: string;

    constructor(obj?: any) {
    this.firstName = obj && obj.firstName || null;
    this.lastName = obj && obj.lastName || null;
    this.email = obj && obj.email || null;
    this.userName = obj && obj.username || null;
    this.passwordHash = obj && obj.password || null;


  }
}
