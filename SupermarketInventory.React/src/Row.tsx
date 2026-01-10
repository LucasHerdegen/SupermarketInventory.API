import type { CartItem, Product } from "./producto";

export default function Row({product, action, showQuantity}: RowProps)
{
    return (
        <tr>
            <th scope="row"> {product.id} </th>
            <th scope="row"> {product.name} </th>
            <th scope="row"> {product.price} </th>
            <th scope="row"> {product.stock} </th>
            <th scope="row"> {product.categoryName} </th>
            <th scope="row"> {action} </th>
            {showQuantity ? <th scope="row"> {product.quantity}  </th> : undefined}
        </tr>
    );
}

interface RowProps
{
    product: Product | CartItem;
    action: React.ReactNode;
    showQuantity?: boolean;
}