import type { Producto } from "./producto";

export default function Row({product}: RowProps)
{
    return (
        <tr>
            <th scope="row"> {product.id} </th>
            <th scope="row"> {product.name} </th>
            <th scope="row"> {product.price} </th>
            <th scope="row"> {product.stock} </th>
            <th scope="row"> {product.categoryName} </th>
        </tr>
    );
}

interface RowProps
{
    product: Producto;
}