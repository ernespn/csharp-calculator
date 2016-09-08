FROM mono:onbuild

EXPOSE 8085

CMD ["mono", "./CalculatorService.exe"]
