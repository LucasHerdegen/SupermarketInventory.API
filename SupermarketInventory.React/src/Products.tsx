import type { Product } from "./producto";
import Table from "./Table";

export default function Products(props: ProductsProps)
{
    console.table(props.products);

    return (
        <div className='container'>
          <h3 className='text-center text-success' > Productos </h3> <br />
          <Table products={props.products} />
        </div> 
    );
}


interface ProductsProps
{
    products: Product[]
} 