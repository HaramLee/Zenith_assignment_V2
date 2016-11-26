export class User {
    username: string;
    password: string;
    firstName: string;
    lastName: string;

    constructor(obj?: any) {
    this.username = obj && obj.username || null;
    this.password = obj && obj.password || null;
    this.firstName = obj && obj.firstName || null;
    this.lastName = obj && obj.lastName || null;

  }
}