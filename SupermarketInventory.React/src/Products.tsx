import { useMemo, useState } from "react";
import type { Product } from "./producto";
import Table from "./Table";

export default function Products({products}: ProductsProps)
{
    console.table(products);

    const [filterString, setFilterString] = useState('');

    const filteredList = useMemo( () => 
        products.filter(p => p.categoryName.toLowerCase().includes(filterString.toLowerCase())), [filterString, products]) 

    return (
        <div className='container'>
            <h3 className='text-center text-success'> Productos </h3> <br />
            <h3> Ingrese una categoria </h3>
            <input type="text" onChange={e => setFilterString(e.target.value)}/>
            <Table products={filteredList} target="products"/>
        </div> 
    );
}


interface ProductsProps
{
    products: Product[]
} 