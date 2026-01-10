interface Product
{
    id: number;
    name: string;
    price: number;
    stock: number;
    categoryName: string;
}

interface CartItem extends Product
{
    quantity: number;
}

export type { Product, CartItem };