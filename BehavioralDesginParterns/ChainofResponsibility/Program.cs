using ChainofResponsibility.Implements;

class Program
{
    static void Main()
    {
        var teamLead = new TeamLead();
        var manager = new Manager();
        var director = new Director();

        teamLead
            .SetNext(manager)
            .SetNext(director);

        teamLead.Approve(500);

        teamLead.Approve(3000);

        teamLead.Approve(10000);
    }
}