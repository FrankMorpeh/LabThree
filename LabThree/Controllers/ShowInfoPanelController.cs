using LabTwo.ViewInteractors.Handlers;

namespace LabTwo.Controllers
{
    public class ShowInfoPanelController
    {
        private List<IPanelHandler> itsPanelHandlers;

        public ShowInfoPanelController(Form1 mainWindow)
        {
            itsPanelHandlers = new List<IPanelHandler>() { mainWindow.mainInfoPanelViewHandler, mainWindow.departmentsInfoPanelViewHandler
                , mainWindow.subjectsOfDepartmentInfoPanelViewHandler, mainWindow.teachersInfoPanelViewHandler
                , mainWindow.studentsOfTeacherInfoPanelViewHandler, mainWindow.auditoriumsInfoPanelViewHandler };
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
