import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";
import CommonStore from "./commomStore";
import ModalStore from "./modalStore";
import UserStore from "./userStore";

interface Store {
    activityStore:ActivityStore;
    commonStore: CommonStore;
    userStore: UserStore;
    modalStore: ModalStore;
}

export const store: Store = {
    activityStore: new ActivityStore(),
    commonStore: new CommonStore(),
    userStore: new UserStore(),
    modalStore: new ModalStore()
}

export const storeContext = createContext(store);

export function useStore() {
    return useContext(storeContext);
}