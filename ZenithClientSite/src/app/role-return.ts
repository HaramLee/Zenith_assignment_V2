export class RoleReturn {
    statusCode : string;
    value: string;

    constructor(obj?: any) {
        this.statusCode =  obj && obj.statusCode || null;
        this.value = obj && obj.value || null;
    }
}
