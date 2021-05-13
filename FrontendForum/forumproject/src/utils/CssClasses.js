import {makeStyles} from "@material-ui/core/styles";



const useStyles = makeStyles((theme) => ({
    root: {
        width: '100%',
        '& > *': {
            margin: theme.spacing(1),
        },
    },
    heading: {
        fontSize: theme.typography.pxToRem(15),
        fontWeight: theme.typography.fontWeightRegular,
    },
}));


export {useStyles};
