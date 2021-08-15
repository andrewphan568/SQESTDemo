import { createContext, useContext } from "react";
import MoistureContentStore from "./moistureContentStore";

interface Store {
    moistureContentStore: MoistureContentStore
}

export const store: Store = {
    moistureContentStore: new MoistureContentStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}