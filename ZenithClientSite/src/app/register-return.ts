export class RegisterReturn {
    statusCode : string;

    constructor(obj?: any) {
        this.statusCode = obj && obj.statusCode || null;
    }
}
