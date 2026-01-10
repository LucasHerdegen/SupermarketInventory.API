import Add from "./Buttons/Add";
import Remove from "./Buttons/Remove";
import type { CartItem, Product } from "./producto";
import Row from "./Row";

export default function Table({products, target, showQuantity}: TableProps)
{
    return (
        <div className="table-responsive">
            <table className="table table-striped table-hover">
                <thead>
                    <tr>
                        <th scope="col"> ID </th>
                        <th scope="col"> Name </th>
                        <th scope="col"> Price </th>
                        <th scope="col"> Stock </th>
                        <th scope="col"> Category </th>
                        <th scope="col"> Actions </th>
                        {showQuantity ? <th scope="col"> Quantity</th> : undefined}
                    </tr>
                </thead>
                <tbody>
                    {products.map(p => <Row key={p.id} product={p} action={target == "products" ? <Add product={p} /> : <Remove product={p}/>} showQuantity={showQuantity}/>)}
                </tbody>
            </table>
        </div>
    );
}

interface TableProps
{
    products: Product[] | CartItem[]
    target: string;
    showQuantity?: boolean;
}