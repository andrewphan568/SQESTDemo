import { makeAutoObservable, runInAction } from "mobx";
import agent from "../agent";
import { MoistureContent } from "../models/apiTypes";

export default class MoistureContentStore {
    loading = false;
    moistureContents: MoistureContent[] = [];
    selectedMoistureContent: MoistureContent | undefined = undefined;

    constructor() {
        makeAutoObservable(this)
    }

    loadMoistureContents = async () => {
        this.loading = true;
        try {
            const moistureContents = await agent.MoistureContents.list();
            runInAction(() => {
                this.moistureContents = moistureContents;
            })
            this.setloading(false);
        } catch (error) {
            this.setloading(false);
        }
    }

    loadMoistureContent = async (id: string) => {
        let moistureContent = this.getMoistureContent(id);
        if (moistureContent) {
            this.selectedMoistureContent = moistureContent;
            return moistureContent;
        } else {
            this.loading = true;
            try {
                moistureContent = await agent.MoistureContents.details(id);
                runInAction(() => {
                    this.selectedMoistureContent = moistureContent;
                })
                this.setloading(false);
                return moistureContent;
            } catch (error) {
                console.log(error);
                this.setloading(false);
            }
        }
    }

    private getMoistureContent = (id: string) => {
        return this.moistureContents.find(m => m.id === id);
    }

    setloading = (state: boolean) => {
        this.loading = state;
    }
}


