import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agents";
import { User, UserFormValues } from "../models/user";
import { store } from "./store";
import { history } from "../..";

export default class UserStore{
    user: User | null = null;

    constructor(){
        makeAutoObservable(this)
    }

    get isLoggedIn(){
        console.log("user is already logged in")
        return !!this.user;
    }
    
    login = async (creds: UserFormValues) => {
        try {
            const user = await agent.Account.login(creds);
            store.commonStore.setToken(user.token);
            runInAction(() => this.user = user);
            history.push('/activities')
            store.modalStore.closeModal();
            console.log(user);
        } catch (error) {
            console.log('Error occurred while trying to login ' + error);
            throw error;
        }
    }

    logout = () => {
        store.commonStore.setToken(null);
        window.localStorage.removeItem('jwt');
        this.user = null;
        history.push('/');
    }

    getUser = async () => {
        try{
        const user = await agent.Account.current();
        runInAction(() => this.user = user);
        } catch(error) {
            console.log(error);
        }
    }

    register = async (creds: UserFormValues) => {
        try {
            const user = await agent.Account.register(creds);
            store.commonStore.setToken(user.token);
            runInAction(() => this.user = user);
            history.push('/activities')
            store.modalStore.closeModal();
            console.log(user);
        }catch (error) {
            console.log('Error occurred while trying to register ' + error);;
            throw error;
        }
    }
    setImage = (image: string) => {
        if (this.user) {
            this.user.image = image;
        }
    }
}