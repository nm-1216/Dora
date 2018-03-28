export function timeInterval(timeStamp) {
    // let conversionTime = timeStr.match(/\d+/g);
    // let unixTime = new Date(conversionTime[0] + '-' + conversionTime[1] + '-' + conversionTime[2] + ' ' + conversionTime[3] + ':' + conversionTime[4] + ':' + conversionTime[5]).getTime();
    // let commonTime = new Date(unixTime)
    // console.log(commonTime)
    function getDateDiff(dateTimeStamp) {
        console.log("213123123123:",new Date().getTimezoneOffset())
        let minute = 1000 * 60;
        let hour = minute * 60;
        let day = hour * 24;
        let halfamonth = day * 15;
        let month = day * 30;
        let now = new Date().getTime();
        let shiqu=(new Date().getTimezoneOffset())/-60
        
        var a=shiqu-8
        now=now+a*60*60*1000

        let diffValue = now - dateTimeStamp;
        if (diffValue < 0) { return; }
        let monthC = diffValue / month;
        let weekC = diffValue / (7 * day);
        let dayC = diffValue / day;
        let hourC = diffValue / hour;
        let minC = diffValue / minute;
        let result = ""
        if (monthC >= 1) {
            result = "" + parseInt(monthC) + "月前";
        }
        else if (weekC >= 1) {
            result = "" + parseInt(weekC) + "周前";
        }
        else if (dayC >= 1) {
            result = "" + parseInt(dayC) + "天前";
        }
        else if (hourC >= 1) {
            result = "" + parseInt(hourC) + "小时前";
        }
        else if (minC >= 1) {
            result = "" + parseInt(minC) + "分钟前";
        } else {
            result = "刚刚";
        }
        return result;
    }
    return getDateDiff(timeStamp)
}

