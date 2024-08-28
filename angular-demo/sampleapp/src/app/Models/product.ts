export class Product {
    productId: number;
    productName: string;
    productCode: string;
    price: number;

    constructor();
    constructor(pId: number, pName: string, pCode: string, price: number);

    constructor(pId?: number, pName?: string, pCode?: string, price?: number) {
        this.productId = pId ?? 0;
        this.productName = pName ?? "";
        this.productCode = pCode ?? "";
        this.price = price ?? 0;
    }
}
