using LabTwo.ViewInteractors.Handlers;

namespace LabTwo.Controllers
{
    public class PanelController // used to show and hide panels
    {
        private List<IPanelHandler> itsPanelHandlers;

        public PanelController(Form1 mainWindow)
        {
            itsPanelHandlers = new List<IPanelHandler>() { mainWindow.mainPanelHandler
                , mainWindow.mainInfoPanelHandler, mainWindow.departmentsInfoPanelHandler
                , mainWindow.subjectsInfoPanelHandler, mainWindow.studentsInfoPanelHandler, mainWindow.teacherInfoPanelHandler
                , mainWindow.studentsOfTeacherInfoPanelHandler, mainWindow.engineerInfoPanelHandler, mainWindow.auditoriumInfoPanelHandler
                , mainWindow.engineersOfAuditoriumInfoPanelHandler, mainWindow.workerByPassportInfoPanelViewHandler };
        }

        public void ShowPanel(IPanelHandler panelHandler)
        {
            foreach (IPanelHandler handler in itsPanelHandlers)
            {
                if (handler != panelHandler)
                    handler.HidePanel();
            }
            panelHandler.ShowPanel();
        }
    }
}