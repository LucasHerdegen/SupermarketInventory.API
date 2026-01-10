import { useContext } from "react";
import type { Product } from "../producto";
import { ShopingCart } from "../ShoppingCart";

export default function Add({ product }: AddProps)
{
    const addProduct = useContext(ShopingCart).addProduct;

    return (
        <button className="btn btn-primary" onClick={ () => addProduct(product) }> Add </button>
    );
}

interface AddProps
{
    product: Product;
}