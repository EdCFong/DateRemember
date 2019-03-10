using System;
using Windows.Storage;
using Windows.ApplicationModel.Resources;
using DataAccess;

public class Date
{

    private int month;
    private int day;
    private string name;
    private string description;
    private string month_Day;
    private string how_many_days_left;
    ResourceLoader loader = new Windows.ApplicationModel.Resources.ResourceLoader();
    public int Days_left_int;
    public int Id_Date { get; set; }
    public int Month
    {
        get { return month; }
    }
    public int Day
    {
        get { return day; }
    }
    public string Name
    {
        get { return name; }
    }
    public string Description
    {
        get { return description; }
    }
    public string Month_Day
    {
        get { return month_Day; }
    }
    public string How_many_days_left
    {
        get { return how_many_days_left; }
    } 
    
    public Date(int a_month, int a_day, string a_name, string a_description)
    {
        month = a_month;
        day = a_day;
        name = a_name;
        description = a_description;
        month_Day = Build_Month_Day_Phrase(month, day);
        how_many_days_left = Days_left();
    }
    
    public void Insert_Data()
    {
        Data_Access_tools.Add_Data(month,day,name,description);
    }
    
    public void Delete_Data(string Name)
    {
        Data_Access_tools.DeleteData(Name);
    }
    private string Build_Month_Day_Phrase(int _month, int _day)
    {
        string month = Put_Month_name(_month);
        string date = month + ", " + Convert.ToString(_day);   // "January, 23" phrase
        return date;
    }
    private string Put_Month_name(int _month)
    {

        switch (_month)
        {
            case 1:
                return loader.GetString("enero");
            case 2:
                return loader.GetString("febrero");
            case 3:
                return loader.GetString("marzo");
            case 4:
                return loader.GetString("abril");
            case 5:
                return loader.GetString("mayo");
            case 6:
                return loader.GetString("junio");
            case 7:
                return loader.GetString("julio");
            case 8:
                return loader.GetString("agosto");
            case 9:
                return loader.GetString("septiembre");
            case 10:
                return loader.GetString("octubre");
            case 11:
                return loader.GetString("noviembre");
            case 12:
                return loader.GetString("diciembre");
            default:
                return loader.GetString("enero");
        }
    }

    // It is used in Tile background tasks 
    public string Get_Month_name_first_three_letters()
    {
        string name = Put_Month_name(month);
        return name.Substring(0, 3);
    }
    private string Days_left()
    {
        int Months;
        int Days;
        ResourceLoader loader = new Windows.ApplicationModel.Resources.ResourceLoader();
        DateTimeOffset now = DateTimeOffset.Now;
        DateTime my_new_date = new DateTime(now.Year, month, day);
        if ((now.Day == my_new_date.Day) && (now.Month == my_new_date.Month))
        {
            return loader.GetString("Is today!");
        }
        else
        {
            DateTimeOffset My_dateTmOffset = new DateTimeOffset(my_new_date);
            TimeSpan difference = My_dateTmOffset - now;            
            Days_left_int = difference.Days;
            if (difference.Days < 0)
            {
                TimeSpan left_of_the_year = new DateTime(now.Year, 12, 31) - now;
                Days_left_int = 360 + difference.Days + left_of_the_year.Days;
            }
            Months = Days_left_int / 30;        //months
            Days = Days_left_int % 30 + 1;     //days      +1 because there is not 0 day
            if(Months == 0)
            {
                if(Days == 1)
                    return loader.GetString("Only_one_left");
                else
                    return loader.GetString("solo") + Days + loader.GetString("faltan");
            }
            else
            {
                if(Months == 1)
                {
                    if (Days == 1)
                        return loader.GetString("Only_one_month") + Days + loader.GetString("Dia_faltan_aun");
                    else
                        return loader.GetString("Only_one_month") + Days + loader.GetString("faltan_aun");
                }       
                else
                {
                    if(Days == 1)
                        return Months + loader.GetString("meses_y") + Days + loader.GetString("Dia_faltan_aun");
                    else
                        return Months +loader.GetString("meses_y") + Days + loader.GetString("faltan_aun");
                }
                    
            }
        }
    }
}

