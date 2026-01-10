import type { Product } from "./producto";
import type { CartItem } from "./ShoppingCart"; 

export default function Row({product, action}: RowProps)
{
    const quantity = (product as CartItem).quantity;

    return (
        <tr>
            <th scope="row"> {product.id} </th>
            <th scope="row"> {product.name} </th>
            <th scope="row"> ${product.price} </th>
            <th scope="row"> { quantity ? `x${quantity}` : product.stock } </th>
            <th scope="row"> {product.categoryName} </th>
            <th scope="row"> {action} </th>
        </tr>
    );
}

interface RowProps
{
    product: Product | CartItem;
    action: React.ReactNode;
    showQuantity?: boolean;
}