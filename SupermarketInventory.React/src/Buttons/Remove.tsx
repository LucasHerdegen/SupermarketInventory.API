import { useContext } from "react";
import type { Product } from "../producto";
import { ShopingCart } from "../ShoppingCart";

export default function Remove({ product }: RemoveProps)
{
    const { removeProduct } = useContext(ShopingCart);

    return (
        <button className="btn btn-primary" onClick={ () => removeProduct(product)}> Remove</button>
    );
}

interface RemoveProps
{
    product: Product;
}