import "./Profile.css"
import React from 'react';
import CustomAccordion from "../../shared/customAccordion/CustomAccordion";
import {IconButton} from "@material-ui/core";
import AddIcon from "@material-ui/icons/Add";
import {useStyles} from "../../../utils/CssClasses";





const Profile = () => {

    const classes = useStyles();

        return (
        <>
            <div className={"profile"}>
                <div className={"image"}>

                </div>
                <h6>#ID:</h6>
                <h3>Username:</h3>
                <h5>Email:</h5>
                <div>
                    <IconButton  id={"add"} aria-label="Add">
                        <AddIcon />
                    </IconButton>
                    Add a post
                </div>

                <div id={"totalPanel"} className={classes.root}>

                    <CustomAccordion/>

                </div>

            </div>
        </>
    );
}

export default Profile;